using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly ILogger<BillService> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<BillRequestDto> _billRequestDtoValidator;

        public BillService(IBillRepository billRepository, ILogger<BillService> logger, IMapper mapper, IValidator<BillRequestDto> billRequestDtoValidator)
        {
            _billRepository = billRepository;
            _logger = logger;
            _mapper = mapper;
            _billRequestDtoValidator = billRequestDtoValidator;
        }

        public async Task<int> AddBillAsync(BillRequestDto billRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _billRequestDtoValidator.ValidateAsync(billRequestDto);
                if (!validationResult.IsValid)
                {
                    return await _billRepository.AddBillAsync(_mapper.Map<Bill>(billRequestDto));
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Billni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Billni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> UpdateBillAsync(int invoiceNumber, BillRequestDto billRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _billRequestDtoValidator.ValidateAsync(billRequestDto);
                if (!validationResult.IsValid)
                {
                    var billResult = await _billRepository.GetBillByInvoiceNumberAsync(invoiceNumber);
                    if (billResult is not null)
                    {
                        billResult.IfLateCheckout = billRequestDto.IfLateCheckout;
                        billResult.PaymentDate = billRequestDto.PaymentDate;
                        billResult.PaymentMode = billRequestDto.PaymentMode;
                        billResult.CreditCardNumber = billRequestDto.CreditCardNumber;
                        billResult.ExpireDate = billRequestDto.ExpireDate;
                        return await _billRepository.UpdateBillAsync(billResult);
                    }
                    else
                    {
                        throw new Exception("Update uchun Bill mavjud emas");
                    }
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada {2} Billni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace, invoiceNumber);
                throw new Exception("Billni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Billni {2} yangilanishida kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace, invoiceNumber);
                throw new Exception("Billni yangilashda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteBillAsync(int invoiceNumber)
        {
            try
            {
                var billResult = await _billRepository.GetBillByInvoiceNumberAsync(invoiceNumber);
                if (billResult is not null)
                {
                    return await _billRepository.DeleteBillAsync(billResult);
                }
                else
                {
                    throw new Exception("Delete uchun bunday Bill mavjud emas");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Billni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Billni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<BillResponseDto>> GetAllBillsAsync()
        {
            try
            {
                return _mapper.Map<List<BillResponseDto>>(await _billRepository.GetAllBillsAsync());
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazada barcha Billarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha billarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<BillResponseDto> GetBillByInvoiceNumberAsync(int invoiceNumber)
        {
            try
            {
                return _mapper.Map<BillResponseDto>(await _billRepository.GetBillByInvoiceNumberAsync(invoiceNumber));
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan Billar boʻyicha Billni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan Billni olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
            }
        }
    }
}
