using System;
using System.Collections.Generic;

namespace Tests_Net_462
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<EvolutionTFRecord> EvolutionExportByCountry(GrainsKey key, int year, long countryId)
        {
            return GetEvolution(key, year,
                (cyStart, cyEnd) => this._unitOfWork.TradeFlowHistory.ExportByCountry(key, countryId, cyStart, cyEnd));
        }

        private IEnumerable<EvolutionTFRecord> GetEvolution(GrainsKey key, int year, Func<DateTime, DateTime, IEnumerable<TradeFlowHistoryEntity>> factory)
        {
            var cropYear = GetCropYear(key.Country, key.Commodity);
            DateTime cyStart = cropYear.CalculateStartDate(year);
            DateTime cyEnd = cropYear.CalculateEndDate(year);

            IEnumerable<TradeFlowHistoryEntity> tf = factory(cyStart, cyEnd);
            var formed = this.FormEvolution(tf);
            IEnumerable<EvolutionTFRecord> result = formed.GroupBy(record => record.ChangeDate.Date,
                (date, records) => records.OrderByDescending(r => r.ChangeDate).ThenByDescending(r => r.TriggersCount).FirstOrDefault());

            return result;
        }
    }

    public class EvolutionTFRecord
    {
        public decimal Value { get; set; }

        public DateTime ChangeDate { get; set; }

        public int TriggersCount { get; set; }
    }

    public class GrainsKey
    {
        public GrainsKey(long commodity, long commodityQuality, long commoditySubQuality, long country)
        {
            Commodity = commodity;
            CommodityQuality = commodityQuality;
            CommoditySubQuality = commoditySubQuality;
            Country = country;
        }

        public long Commodity { get; }
        public long CommodityQuality { get; }
        public long CommoditySubQuality { get; }
        public long Country { get; }
    }
}
