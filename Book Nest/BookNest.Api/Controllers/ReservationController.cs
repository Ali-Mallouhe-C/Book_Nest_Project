using AutoMapper;
using BookNest.Api.DTOs.RequestDTO;
using BookNest.Api.DTOs.ResponseDTO;
using BookNest.Domain.Entities;
using BookNest.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Reservation> _repository;
        private readonly IBaseRepository<Book> _bookRepository;

        public ReservationController(IMapper mapper,
                                     IBaseRepository<Reservation> repository, 
                                     IBaseRepository<Book> bookRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _bookRepository = bookRepository;
        }

        [HttpGet("{id}", Name = "GetReservationById")]
        public async Task<ActionResult<ReservationResponseDTO>> GetReservationById(int id)
        {
            // جلب الحجز بناءً على المعرّف
            var reservation = await _repository.GetByIdAsync(id);
            if (reservation == null)
                return NotFound(); // إذا لم يتم العثور على الحجز

            // تحويل الحجز إلى نموذج استجابة
            var reservationResponse = _mapper.Map<ReservationResponseDTO>(reservation);

            return Ok(reservationResponse); // إرجاع تفاصيل الحجز
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation([FromBody] ReservationRequestDTO reservationDTO)
        {
            if (reservationDTO == null || !ModelState.IsValid)
                return BadRequest();

            // تحويل البيانات الواردة إلى كيان الحجز
            var reservation = _mapper.Map<Reservation>(reservationDTO);

            // تطبيق منطق التسعير حسب الكمية المتوفرة
            await ApplyPricingLogic(reservation);

            // إضافة الحجز إلى قاعدة البيانات
            var response = await _repository.AddAsync(reservation);

            // إرسال رسالة واتساب لتأكيد الحجز
            //await SendWhatsAppMessageToUser(reservation);

            return CreatedAtRoute(nameof(GetReservationById), new { response.Id }, response);
        }

        private async Task ApplyPricingLogic(Reservation reservation)
        {
            // جلب الكتاب بناءً على BookId من الحجز
            var book = await _bookRepository.GetByIdAsync(reservation.BookId); // افترض أنك تستخدم نفس المستودع

            if (book == null)
                throw new Exception("الكتاب غير موجود");

            // الحصول على الكمية المتاحة
            var availableQuantity = book.Quantity;

            if (reservation.BookNumber > availableQuantity)
            {
                // حساب السعر لكل كتاب غير متوفر
                var shortageCount = reservation.BookNumber - availableQuantity;
                var regularPrice = book.Price; // سعر الكتاب العادي

                // زيادة السعر بنسبة 10%
                var increasedPrice = regularPrice * 1.10m;

                // حساب السعر الإجمالي
                reservation.Total = (availableQuantity * regularPrice) + (shortageCount * increasedPrice);
            }
            else
            {
                // إذا كانت الكمية المطلوبة أقل أو تساوي الكمية المتاحة
                reservation.Total = reservation.BookNumber * book.Price;
            }
        }


    }
}
