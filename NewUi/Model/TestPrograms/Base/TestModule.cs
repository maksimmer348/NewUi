using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    public abstract class TestModule
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual string ToFormString()
        {
            return null;
        }

    }
}