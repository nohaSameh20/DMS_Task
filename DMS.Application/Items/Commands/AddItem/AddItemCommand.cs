using Application.Interfaces;
using DMS.Application.Interfaces;
using Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Items.Commands
{
    public class AddItemCommand : IAddItemCommand
    {
        IDatabaseService databaseService;
        IAddItemFactory addItemFactory;
        IFileManagerService fileManagerService;
        public AddItemCommand(IDatabaseService databaseService, IAddItemFactory addItemFactory, IFileManagerService fileManagerService)
        {
            this.databaseService = databaseService;
            this.addItemFactory = addItemFactory;
            this.fileManagerService = fileManagerService;
        }
        public Guid Execute(AddItemModel model)
        {
            if (model == null || !model.ValidationState.IsValid)
                throw new ValidationsException("Add New Item not valid", model.ValidationState.ValidationResults);

            var isItemExist = databaseService.Items.Any(obj => obj.Id == Guid.Empty&&obj.Name==model.Name);
            if (isItemExist)
                throw new BusinessException("Item is already exist", "ItemDuplicated");
            Item item = addItemFactory.Create(model);
            if (!string.IsNullOrEmpty(model.Image))
            {
                var imagePath = fileManagerService.UploadImage(Guid.NewGuid().ToString(), "JPEG", model.Image, "Images");

                if (imagePath == null)
                    throw new BusinessException("Image not saved", "ImageNotSaved");
                item.Image = imagePath;
            };
            databaseService.Items.Add(item);
            databaseService.SaveChanges();
            return item.Id;
        }
    }
}
