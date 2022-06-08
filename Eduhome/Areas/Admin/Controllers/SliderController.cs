using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using Business;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eduhome.Areas.Admin.Controllers
{
   
    [Area("Admin")]
    public class SliderController : Controller
    {

        private readonly ISlidersService _sliderService;

        public SliderController(ISlidersService service)
        {
            _sliderService = service;
        }


        //Index
        public async Task<IActionResult> Index()
        {
            List<Slider> datas = new List<Slider>();

            try
            {
                datas = await _sliderService.GetAll();
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }

            return View(datas);
        }

        //Details
        public async Task<IActionResult> Details(int? id)
        {
            Slider data = new Slider();

            try
            {
                data = await _sliderService.Get(id);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }

            return View(data);
        }


        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {

            try
            {
                await _sliderService.Create(slider);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
        }


        //Edit
        public async Task<IActionResult> Edit(int? id)
        {
            var data = await _sliderService.Get(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Slider data)
        {
            try
            {
                await _sliderService.Update(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
        }


        //Delete
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _sliderService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
        }


    }
}
