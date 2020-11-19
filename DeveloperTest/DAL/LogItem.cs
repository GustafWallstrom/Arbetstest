using Core.Controls;
using Core.DAL;
using System;
using System.Data;

namespace DeveloperTest.DAL
{
    [dbTable("logitem"), dbIdField("Id")]
    public class LogItem : dbBase, IAutoDbCreator
    {
        public LogItem() { }
        public LogItem(IDataRecord row) : base(row) { }
        public LogItem(int id) : base(id) { }

        [dbField("Id", true), Title("Id")]
        public int Id { get; set; }

        private Guid _guid;

        [dbField("UniqueId", SqlDbType.Binary, 16, Index = true)]
        public Guid UniqueId
        {
            get
            {
                if (_guid == default(Guid))
                    _guid = Guid.NewGuid();

                return _guid;
            }
            set
            {
                _guid = value;
            }
        }

        [dbField("Date"), Title("Datum")]
        public DateTime Date { get; set; }

        [dbField("User"), Title("Svarande")]
        public string User { get; set; }

        [dbField("Company"), Title("Företag")]
        public string Company { get; set; }

        [dbField("Contact"), Title("Kontaktperson")]
        public string Contact { get; set; }

        [dbField("Phone"), Title("Telefon 1")]
        public string Phone { get; set; }

        [dbField("PhoneAlt"), Title("Telefon 2")]
        public string PhoneAlt { get; set; }

        [dbField("Email"), Title("E-post")]
        public string Email { get; set; }

        [dbField("Question"), Title("Fråga")]
        public string Question { get; set; }

        [dbField("Answer"), Title("Svar")]
        public string Answer { get; set; }

        [dbField("Comment"), Title("Åtgärd/kommentar")]
        public string Comment { get; set; }

        [dbField("EditedBy"), Title("Redigerad av")]
        public string EditedBy { get; set; }

        public override object Save()
        {
            var isNew = ObjectState == eObjectState.New;
            var id = SaveReturnInt();

            if (isNew)
            {
                Id = id;
                LogItemHelper.AllLogs.Add(this);
            }

            return id;
        }
    }
}