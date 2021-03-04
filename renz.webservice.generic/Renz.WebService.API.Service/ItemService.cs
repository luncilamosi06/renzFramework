using AutoMapper;
using RivTech.WebService.Generic.Data.Entity;
using RivTech.WebService.Generic.DataProvider.Repository;
using RivTech.WebService.Generic.DTO;
using RivTech.WebService.Generic.Service.Exceptions;
using RivTech.WebService.Generic.Service.Services;
using System.Collections.Generic;

namespace RivTech.WebService.Generic.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public List<ItemDTO> GetAll()
        {
            var data = _itemRepository.FindAll();
            var result = _mapper.Map<List<ItemDTO>>(data);

            return result;
        }

        public string InsertItem(ItemDTO model)
        {
            var data = _mapper.Map<LvItem>(model);

            return _itemRepository.Add(data);
        }

        public ItemDTO GetItem(byte itemId)
        {
            var data = _itemRepository.Find(itemId);
            if(data == null) throw new ModelNotFoundException("Item record does not exists.");

            var result = _mapper.Map<ItemDTO>(data);

            return result;
        }

        public string UpdateItem(ItemDTO model)
        {
            var data = _mapper.Map<LvItem>(model);
            return _itemRepository.Update(data);
        }


        public string RemoveItem(byte itemId)
        {
            return _itemRepository.Remove(itemId);
        }

    }


}
