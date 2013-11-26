﻿using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.InstallmentCalculationPolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IInstallmentCalculationPolicy))]
    [ExportMetadata("Order", 10)]
    [PolicyAttribute(Implementation = "Flat")]
    public class FlatInstallmentCalculationPolicy : BaseInstallmentCalculationPolicy, IInstallmentCalculationPolicy
    {
        public void Calculate(IInstallment installment, IScheduleConfiguration configuration)
        {
            var number = configuration.NumberOfInstallments - configuration.GracePeriod;
            installment.Principal = configuration.RoundingPolicy.Round(configuration.Amount / number);
            installment.Interest = CalculateInterest(installment, configuration, configuration.Amount);
        }
    }
}
