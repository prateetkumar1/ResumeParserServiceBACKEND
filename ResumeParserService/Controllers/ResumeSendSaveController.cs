using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeParserService.Context;
using ResumeParserService.Services;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace ResumeParserService.Controllers
{
    [Route("api/ResumeSend")]
    public class ResumeSendSaveController : Controller
    {
        IResumeSaveService _resumeSaveService;
        public ResumeSendSaveController(IResumeSaveService resumeSaveService)
        {
            _resumeSaveService = resumeSaveService;
        }


        // GET: ResumeSend
        [HttpGet("{resumepath}/{fileType}")]
        public ActionResult Index(string resumepath, string fileType)
        {
            var applicationType = "";
            if (fileType == "docs")
            {
                applicationType = "application/octet-stream";
            } else
            {
                applicationType = "application/pdf";
            }
            string filePath = "D:/Resume_Parser-master/ResumeParserService/ResumeParserService/Resumes/";
            var combimePath = filePath + resumepath;
            var file = System.IO.File.ReadAllBytes(combimePath);
            return File(file, applicationType, resumepath);
        }

        // GET: ResumeSend/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResumeSend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResumeSend/Create
        [Route("~/api/ResumeSave")]
        [HttpPost]
        public IActionResult Upload()
        {
            try
            {                
                var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                var file = Request.Form.Files[0];                
                var folderName = Path.Combine("Resumes");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if(file.Length>0)
                {
                    var fileName = timestamp+ "_" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    _resumeSaveService.Create(file, dbPath);
                    return Ok(new { message = "success", StatusCode = Response.StatusCode, MemberList = "success" });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server error" + ex.Message);
            }
        }

        // GET: ResumeSend/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResumeSend/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResumeSend/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResumeSend/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    public class ResumeSaveInternalModel
    {
        public IFormFile Resumes { get; set; }
        public string CandidateName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }       
    }
}
