using Application.Interfaces;
using DMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Application.Items
{
    public class GetItemsQuery : IGetItemsQuery
    {
        IDatabaseService databaseService;
        IFileManagerService fileManagerService;
        public GetItemsQuery(IDatabaseService databaseService, IFileManagerService fileManagerService)
        {
            this.databaseService = databaseService;
            this.fileManagerService = fileManagerService;
        }
        public List<GetItemsQueryResult> Execute()
        {
            var query = databaseService.Items.GetAll();

            var res = query.OrderByDescending(obj => obj.CreatedAt)
                           .Select(obj => new GetItemsQueryResult()
                          {
                              Id = obj.Id,
                              Image = fileManagerService.GetPath(obj.Image),
                              Description=obj.Description,
                              Name=obj.Name,
                              Price=obj.Price,
                              QTY=obj.QTY,
                              UOM=obj.UOM
                          }).ToList();

            return res;
        }
    }
}
