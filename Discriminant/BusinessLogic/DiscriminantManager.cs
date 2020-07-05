using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.ModelsBL;
using DAL;
using DAL.Interfaces;
using DAL.ModelsDal;
using System;

namespace BusinessLogic
{
    public class DiscriminantManager : IRepositoryBl
    {
        public readonly IRepositoryDal _discriminantRepository;

        private readonly Mapper _mapper;

        public DiscriminantManager()
        {
            _discriminantRepository = new DiscriminantRepository();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Equation, EquationBl>();
                cfg.CreateMap<EquationBl, Equation>();
            });

            _mapper = new Mapper(conf);
        }

        public double DiscriminantCalculate(EquationBl equationBl)
        {
            var discriminant = Math.Pow(equationBl.B, 2) - 4 * equationBl.A * equationBl.C;

            equationBl.Discriminant = discriminant;

            var equationDal = _mapper.Map<Equation>(equationBl);

            _discriminantRepository.DiscriminantCalculation(equationDal);

            return discriminant;
        }

        public GetRootsResult CalculateRoots(EquationBl equationBl)
        {
            var roots = new GetRootsResult();

            if (equationBl.Discriminant < 0)
            {
                equationBl.FirstRoot = null;
                equationBl.SecondRoot = null;
            }
            if (equationBl.Discriminant == 0)
            {
                equationBl.FirstRoot = -equationBl.B / (2 * equationBl.A);
                equationBl.SecondRoot = null;
            }
            if (equationBl.Discriminant > 0)
            {
                equationBl.FirstRoot = (-equationBl.B + Math.Sqrt(equationBl.Discriminant)) / (2 * equationBl.A);
                equationBl.SecondRoot = (-equationBl.B - Math.Sqrt(equationBl.Discriminant)) / (2 * equationBl.A);
            }

            roots.FirstRoot = equationBl.FirstRoot;
            roots.SecondRoot = equationBl.SecondRoot;

            var equation = _mapper.Map<Equation>(equationBl);

            _discriminantRepository.CalculateRoots(equation);

            return roots;
        }
    }
}
