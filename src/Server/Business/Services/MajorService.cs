using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class MajorService : IMajorService
    {
        private IMajorRepository _majorRepository;
        private Major? _major;

        public MajorService(IMajorRepository majorRepository)
        {
            _majorRepository = majorRepository;
            _major = null;
        }

        public async Task<bool> DeleteMajorAsync(int majorID)
        {
            return await _majorRepository.DeleteMajorAsync(majorID);
        }

        public async Task<MajorResponse?> AddMajorAsync(MajorRequest request)
        {
            _major = new Major();
            _major = _major.RequestToMajor(request);

            if(_major != null)
            {
                _major.MajorID = await _majorRepository.AddMajorAsync(_major);

                if (_major.MajorID != -1)
                    return _major.MajorToResponse();
            }

            return null;
        }

        public async Task<MajorResponse?> UpdateMajorAsync(MajorRequest request, int majorID)
        {
            _major = new Major();
            _major = _major.RequestToMajor(request, majorID);

            if (_major != null && await _majorRepository.UpdateMajorAsync(_major))
                return _major.MajorToResponse();

            return null;
        }

        public async Task<IEnumerable<MajorResponse>?> GetPagedMajorsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Major>? majors = await _majorRepository.GetPagedMajorsAsync(pageNumber, pageSize);
            return majors?.Select(m => m.MajorToResponse()).OfType<MajorResponse>();
        }

        public async Task<MajorResponse?> GetMajorByIDAsync(int majorID)
        {
            _major = await _majorRepository.GetMajorByIDAsync(majorID);
            return _major != null ? _major.MajorToResponse() : null;
        }
    }
}
