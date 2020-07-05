﻿using AutoMapper;
using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.ModelsBL;
using Discriminant.Models;
using System.Web.Mvc;

namespace Discriminant.Controllers
{
    public class DiscriminantController : Controller
    {
        // GET: Discriminant

        public readonly IRepositoryBl _repositoryBl;

        public readonly Mapper _mapper;

        public DiscriminantController()
        {
            _repositoryBl = new DiscriminantManager();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EquationBl, EquationPl>();
                cfg.CreateMap<EquationPl, EquationBl>();
            });

            _mapper = new Mapper(conf);
        }

        [HttpGet]
        public ActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(EquationPl equationPl)
        {
            var equation = _mapper.Map<EquationBl>(equationPl);

            var result = _repositoryBl.DiscriminantCalculate(equation);

            equationPl.Discriminant = result;

            GetRootsResult roots = _repositoryBl.CalculateRoots(equation);

            equationPl.FirstRoot = roots.FirstRoot;

            equationPl.SecondRoot = roots.SecondRoot;

            return View("CalculateResult", equationPl);
        }
    }   
}