using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Repository
{
    class StatusesRepository
    {
        private List<string> _statuses = new List<string>();

        public StatusesRepository()
        {
            _statuses.Add("Первычный контакт");
            _statuses.Add("Переговоры");
            _statuses.Add("Согласование договора");
            _statuses.Add("В работе");
            _statuses.Add("Закончен");
        }

        public List<string> GetStatuses()
        {
            return new List<string>(_statuses);
        }
        public string Get(int index)
        {
            if (index < 0 || index >= _statuses.Count)
                throw new IndexOutOfRangeException("StatusesRepository.Get(" + index + ")");

            return _statuses[index];
        }
    }
}
