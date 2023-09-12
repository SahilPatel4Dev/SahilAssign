using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SahilAssign.Data;
using SahilAssign.Models;
using SahilAssign.Models.Domain;

namespace SahilAssign.Controllers
{
    public class SettingController : Controller
    {
        private readonly MVCDemoDbContext mvcDemo;

        public SettingController(MVCDemoDbContext mvcDemo)
        {
            this.mvcDemo = mvcDemo;
        }
        [HttpGet]
        public IActionResult Add()
        {         
            return View();
        }
        public async Task<IActionResult> Index()
        {
          var SettingData= await mvcDemo.Settings.Where(x=>x.IsDeleted==true).ToListAsync();
            return View(SettingData);
        }
        public async Task<IActionResult> Add(AddSetting addSetting)
        {
            var addset = new Setting()
            {
                Key = addSetting.Key,
                Value = addSetting.Value,
                Value2 = addSetting.Value2,
                Created = addSetting.Created,
                LastModified = addSetting.LastModified,
                Description = addSetting.Description,
                IsDeleted = true                
            };
         await mvcDemo.Settings.AddAsync(addset);
            await mvcDemo.SaveChangesAsync();
            return RedirectToAction("Add");

        }
        [HttpGet]
        public async Task<IActionResult> View(int Id)
        {

           var stdata =await mvcDemo.Settings.FirstOrDefaultAsync(x => x.Id == Id);
            if(stdata!=null)
            {
                var SettingData = new Setting()
                {
                    Id = stdata.Id,
                    Key = stdata.Key,
                    Value=stdata.Value,
                    Value2=stdata.Value2,   
                    Description= stdata.Description,
                    Created=stdata.Created, 
                    LastModified = stdata.LastModified,
                };
                return await Task.Run(()=> View("View",SettingData));
            }

            return RedirectToAction("Add");

        }

        public async Task<IActionResult> View(Setting model)
        {

            var StData = await mvcDemo.Settings.FindAsync(model.Id);
            if(StData!=null)
            {
                StData.Key= model.Key;
                StData.Value= model.Value;
                StData.Value2 = model.Value2;
                StData.Description = model.Description;
                StData.Created = model.Created;
                StData.LastModified=model.LastModified;
                StData.IsDeleted = true;
               await mvcDemo.SaveChangesAsync() ;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int Id)
        {

            var StData = await mvcDemo.Settings.FindAsync(Id);
            if (StData != null)
            {
               
                StData.IsDeleted = false;
                await mvcDemo.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
