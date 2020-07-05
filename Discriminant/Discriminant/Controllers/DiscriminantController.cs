using AutoMapper;
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
                cfg.CreateMap<EquationResultBl, EquationResultPl>();
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

            var discriminant = _repositoryBl.DiscriminantCalculate(equation);

            EquationResultBl rootsBl = _repositoryBl.CalculateRoots(equation, discriminant);

            var rootsPl = _mapper.Map<EquationResultPl>(rootsBl);

            rootsPl.Discriminant = discriminant;

            return View("CalculateResult", rootsPl);
        }
    }   
}