using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;
using DataAccessLayer.DBML;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Converters;

namespace DataAccessLayer.DAL
{
    public class SourceSystemDAL : ISourceSystemDAL
    {
        public List<SourceSystemPOCO> DisplaySourceSystemName()
        {
            List<SourceSystemPOCO> sourceList = null;

            try
            {
                MDMDataContext context = new MDMDataContext();
                var sourceSystem = (from c in context.SourceSystems
                                    select c).ToList();

                sourceList = new List<SourceSystemPOCO>();
                if (sourceSystem != null)
                {
                    foreach (var e in sourceSystem)
                    {
                        SourceSystemPOCO et = MappingConverter.ConvertSourceSystemPOCO(e);
                        sourceList.Add(et);
                    }

                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return sourceList;
        }

        public string GetSourceSystemName(int sourceSystemId)
        {
            string sourceSystemName = null;
            try
            {
                MDMDataContext context = new MDMDataContext();
                sourceSystemName = (from sourceSystem in context.SourceSystems
                                    where sourceSystem.SystemId == sourceSystemId
                                    select sourceSystem.SystemName).SingleOrDefault();
                if (sourceSystemName == null)
                {
                    return String.Empty;
                }
            }
            catch (ArgumentNullException)
            {

                return String.Empty;//Display Exception
            }
            return sourceSystemName;
        }

        public IEnumerable<SourceSystemPOCO> GetAllSourceSystems()
        {
            MDMDataContext context = new MDMDataContext();
            List<SourceSystemPOCO> mappingPOCOList = new List<SourceSystemPOCO>();
            IEnumerable<SourceSystem> list = from sourceSystem in context.SourceSystems
                                       select sourceSystem;
            foreach (var source in list)
            {
                mappingPOCOList.Add(MappingConverter.ConvertSourceSystemPOCO(source));
            }

            return mappingPOCOList;
        }

        public int GetSourceSystemID(string sourceSystemName)
        {
            int sourceSystemID = 0;
            try
            {
                MDMDataContext context = new MDMDataContext();
                sourceSystemID = (from sourceSystem in context.SourceSystems
                                  where sourceSystem.SystemName == sourceSystemName
                                  select sourceSystem.SystemId).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return sourceSystemID;
        }

    }
}
