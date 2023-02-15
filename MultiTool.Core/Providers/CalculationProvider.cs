using System.Numerics;

namespace MultiTool.Core.Providers
{
    public interface ICalculationProvider
    {
        double GetVectorLength(params double[] values);
    }
    public class CalculationProvider: ICalculationProvider
    {
        ILogger<CalculationProvider> _log;
        public CalculationProvider(ILogger<CalculationProvider> log)
        {
            _log = log;
        }

        public double GetVectorLength(params double[] values)
        {
            _log.LogInformation($"Started vector {values} length calculation");
            try
            {
                return Math.Sqrt(values.Select(v => Math.Abs(v * v)).Sum());
            }
            catch(ArgumentNullException ex)
            {
                _log.LogError("Vector length calculation failed; One of arguments was null",ex);
                return -1;
            }


        }
    }
}
