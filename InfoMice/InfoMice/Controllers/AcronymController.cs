﻿

namespace InfoMice.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml.Linq;
    using Models;
    using Repositories;
    using ViewModels;

    public class AcronymController : Controller
    {
        //
        // GET: /Acronym/

        public List<Acronym> listAcronyms { get; set; }

        public AcronymContext myCtxt { get; set; }

        private AcroymnRepository myRepo { get; set; }

        public AcronymController()
        {

            //var resourceName = "InfoMice.SeedData.acronyms.xml";
            //var assembly = Assembly.GetExecutingAssembly();
            //var stream = assembly.GetManifestResourceStream(resourceName);
            //var xml = XDocument.Load(stream);
            //var acronyms = xml.Element("acronyms")
            //                  .Elements("acronym")
            //                  .Select((a, index) => new Acronym
            //                  {
            //                      AcronymId = index,
            //                      Abreviation = (string)a.Element("abrev"),
            //                      FullName = (string)a.Element("meaning")
            //                  }).ToArray();


            myCtxt = new AcronymContext();
            myRepo = new AcroymnRepository(myCtxt);

            List<Acronym> list = new List<Acronym>();
            foreach (Acronym acronym in myRepo.GetAll())
            {
                list.Add(acronym);
            }

            listAcronyms = list;
        }

        //public ActionResult Index()
        //{
        //    ViewBag.Acronyms = listAcronyms;
        //    return View();
        //}

        public ActionResult Index(string Search)
        {
            if (string.IsNullOrWhiteSpace(Search))
            {
                ViewBag.Acronyms = listAcronyms;
            }
            else
            {
                var test = from a in listAcronyms
                           where a.Abreviation.ToUpper().Contains(Search.ToUpper())
                           select a;
                ViewBag.Acronyms = test;
            }

            return View();
        }

        //
        // GET: /Acronym/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Acronym/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Acronym/Create

        [HttpPost]
        public ActionResult Create(Acronym acronym)
        {
            try
            {



                Acronym ac = new Acronym();
                ac.FullName = acronym.FullName;
                ac.Meaning = acronym.Meaning;
                ac.Abreviation = acronym.Abreviation;
                ac.Type = acronym.Type;

                myRepo.Insert(ac);
                myCtxt.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Acronym/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Acronym/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Acronym/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Acronym/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
