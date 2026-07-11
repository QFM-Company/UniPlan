using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class MajorService : IMajorService
    {
        private readonly IMajorRepository _majorRepository;
        private readonly IValidationService _validationService;
        public MajorService(IMajorRepository majorRepository, IValidationService validationService)
        {
            _majorRepository = majorRepository;
            _validationService = validationService;
        }

        public async Task<bool> DeleteMajorAsync(int majorID)
        {
            return majorID > 0 && await _majorRepository.DeleteMajorAsync(majorID);
        }

        public async Task<MajorResponse?> AddMajorAsync(MajorRequest request)
        {
            _validationService.Validate(request);

            Major major = request.ToMajor();

            major.MajorID = await _majorRepository.AddMajorAsync(major);

            if (major.MajorID != -1)
                return major.ToResponse();

            return null;
        }

        public async Task<bool> UpdateMajorAsync(MajorRequest request, int majorID)
        {
            _validationService.Validate(request);

            Major? major = await _majorRepository.GetMajorByIDAsync(majorID);

            major?.UpdateMajor(request);

            if (major != null)
                return await _majorRepository.UpdateMajorAsync(major);

            return false;
        }

        public async Task<IEnumerable<MajorResponse>?> GetPagedMajorsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Major>? majors = await _majorRepository.GetPagedMajorsAsync(pageNumber, pageSize);
            return majors?.Select(m => m.ToResponse()).OfType<MajorResponse>();
        }

        public async Task<MajorResponse?> GetMajorByIDAsync(int majorID)
        {
            if (majorID <= 0)
                return null;

            Major? major = await _majorRepository.GetMajorByIDAsync(majorID);
            return major != null ? major.ToResponse() : null;
        }
    }
}
