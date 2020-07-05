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
            var results = new EquationResultBl();

            var discriminant = Math.Pow(equationBl.B, 2) - 4 * equationBl.A * equationBl.C;

            results.Discriminant = discriminant;

            return discriminant;
        }

        public EquationResultBl CalculateRoots(EquationBl equationBl, double discriminant)
        {
            var results = new EquationResultBl();

            if (discriminant < 0)
            {
                results.FirstRoot = null;
                results.SecondRoot = null;
            }
            if (discriminant == 0)
            {
                results.FirstRoot = -equationBl.B / (2 * equationBl.A);
                results.SecondRoot = null;
            }
            if (discriminant > 0)
            {
                results.FirstRoot = (-equationBl.B + Math.Sqrt(discriminant)) / (2 * equationBl.A);
                results.SecondRoot = (-equationBl.B - Math.Sqrt(discriminant)) / (2 * equationBl.A);
            }

            var equation = new Equation() { A = equationBl.A, B = equationBl.B, C = equationBl.C, Discriminant = discriminant, FirstRoot = results.FirstRoot, SecondRoot = results.SecondRoot };

            _discriminantRepository.SaveResults(equation);

            return results;
        }
    }
}
