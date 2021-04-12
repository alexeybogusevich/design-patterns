using System;
using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }

    public class CodeBuilder
    {
        private CodeClass Class;

        private class CodeField
        { 
            public CodeField(string name, string type)
            {
                Name = name;
                Type = type;
            }

            public string Name { get; private set; }
            public string Type { get; private set; }
        }

        private class CodeClass
        {
            public CodeClass(string name)
            {
                Name = name;
                Fields = new List<CodeField>();
            }

            public string Name { get; private set; }
            public List<CodeField> Fields { get; private set; }
        }

        public CodeBuilder(string className)
        {
            Class = new CodeClass(className);
        }

        public CodeBuilder AddField(string name, string type)
        {
            Class.Fields.Add(new CodeField(name, type));
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {this.Class.Name}");
            sb.AppendLine("{");
            foreach (var field in this.Class.Fields)
            {
                sb.AppendLine($"  public {field.Type} {field.Name};");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
