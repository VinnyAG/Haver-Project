﻿using Haver.Models;
using System.Collections.Generic;

namespace Haver.Utilities
{
    public class CalculateNCRTimeCounters
    {

        public CalculateNCRTimeCounters()
        {
        }

        public (int qual24, int qual48, int qual5, int qualTotal) QualCounters(List<NCR> QualNCRs)
        {
            int qualTotal = 0;
            int qual24 = 0;
            int qual48 = 0;
            int qual5 = 0;

            foreach (var ncr in QualNCRs)
            {
                TimeSpan differenceLastFilled = DateTime.Now - ncr.CreatedOn;
                int LastFilled = differenceLastFilled.Days;
                qualTotal++;

                //Count the amount of days at each category
                if (LastFilled == 1)
                {
                    qual24++;
                }
                else if (LastFilled == 2)
                {
                    qual48++;
                }
                else if (LastFilled >= 5)
                {
                    qual5++;
                }
            }

            return (qual24, qual48, qual5, qualTotal);
        }
        public (int eng24, int eng48, int eng5, int engTotal) EngCounters(List<NCR> EngNCRs)
        {
            int engTotal = 0;
            int eng24 = 0;
            int eng48 = 0;
            int eng5 = 0;

            foreach (var ncr in EngNCRs)
            {
                int LastFilled = 0;

                // Converting DateOnly to DateTime by providing Time Info
                if (ncr.QualityRepresentative != null)
                {
                    DateTime qualDateTime = ncr.QualityRepresentative.QualityRepDate.ToDateTime(TimeOnly.Parse(Convert.ToString(ncr.CreatedOn.TimeOfDay)));
                    TimeSpan differenceLastFilled = DateTime.Now - qualDateTime;
                    LastFilled = differenceLastFilled.Days;
                    engTotal++;
                }

                //Count the amount of days at each category
                if (LastFilled == 1)
                {
                    eng24++;
                }
                else if (LastFilled == 2)
                {
                    eng48++;
                }
                else if (LastFilled >= 5)
                {
                    eng5++;
                }
            }

            return (eng24, eng48, eng5, engTotal);
        }

        public (int oper24, int oper48, int oper5, int operTotal) OperCounters(List<NCR> OperNCRs)
        {
            int operTotal = 0;
            int oper24 = 0;
            int oper48 = 0;
            int oper5 = 0;

            foreach (var ncr in OperNCRs)
            {
                int LastFilled = 0;

                // Converting DateOnly to DateTime by providing Time Info
                if (ncr.Engineering != null && ncr.QualityRepresentative.ConfirmingEng != false)
                {
                    DateTime engDateTime = ncr.Engineering.EngineeringDate.ToDateTime(TimeOnly.Parse(Convert.ToString("11:59 PM")));
                    TimeSpan differenceLastFilled = DateTime.Now - engDateTime;
                    LastFilled = differenceLastFilled.Days;
                    operTotal++;
                }
                else if (ncr.QualityRepresentative != null)
                {
                    DateTime qualDateTime = ncr.QualityRepresentative.QualityRepDate.ToDateTime(TimeOnly.Parse(Convert.ToString(ncr.CreatedOn.TimeOfDay)));
                    TimeSpan differenceLastFilled = DateTime.Now - qualDateTime;
                    LastFilled = differenceLastFilled.Days;
                    operTotal++;
                }

                //Count the amount of days at each category
                if (LastFilled == 1)
                {
                    oper24++;
                }
                else if (LastFilled == 2)
                {
                    oper48++;
                }
                else if (LastFilled >= 5)
                {
                    oper5++;
                }
            }

            return (oper24, oper48, oper5, operTotal);
        }

        public (int proc24, int proc48, int proc5, int procTotal) ProcCounters(List<NCR> ProcNCRs)
        {
            int procTotal = 0;
            int proc24 = 0;
            int proc48 = 0;
            int proc5 = 0;

            foreach (var ncr in ProcNCRs)
            {
                int LastFilled = 0;

                // Converting DateOnly to DateTime by providing Time Info
                if (ncr.Operations != null)
                {
                    DateTime operDateTime = ncr.Operations.OperationsDate.ToDateTime(TimeOnly.Parse(Convert.ToString("11:59 PM")));
                    TimeSpan differenceLastFilled = DateTime.Now - operDateTime;
                    LastFilled = differenceLastFilled.Days;
                    procTotal++;
                }

                //Count the amount of days at each category
                if (LastFilled == 1)
                {
                    proc24++;
                }
                else if (LastFilled == 2)
                {
                    proc48++;
                }
                else if (LastFilled >= 5)
                {
                    proc5++;
                }
            }

            return (proc24, proc48, proc5, procTotal);
        }

        public (int reinsp24, int reinsp48, int reinsp5, int reinspTotal) ReinspCounters(List<NCR> ReinspNCRs)
        {
            int reinspTotal = 0;
            int reinsp24 = 0;
            int reinsp48 = 0;
            int reinsp5 = 0;

            foreach (var ncr in ReinspNCRs)
            {
                int LastFilled = 0;

                // Converting DateOnly to DateTime by providing Time Info
                if (ncr.Procurement != null)
                {
                    DateTime prcoDateTime = ncr.Procurement.ProcurementDate.ToDateTime(TimeOnly.Parse(Convert.ToString("11:59 PM")));
                    TimeSpan differenceLastFilled = DateTime.Now - prcoDateTime;
                    LastFilled = differenceLastFilled.Days;
                    reinspTotal++;
                }

                //Count the amount of days at each category
                if (LastFilled == 1)
                {
                    reinsp24++;
                }
                else if (LastFilled == 2)
                {
                    reinsp48++;
                }
                else if (LastFilled >= 5)
                {
                    reinsp5++;
                }
            }

            return (reinsp24, reinsp48, reinsp5, reinspTotal);
        }
    }
}
