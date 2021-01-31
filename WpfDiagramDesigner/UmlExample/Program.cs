using MetaDslx.Languages.Uml.Model;
using MetaDslx.Languages.Uml.Serialization;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace UmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            UmlDescriptor.Initialize();
            var umlSerializer = new WhiteStarUmlSerializer();
            var model = umlSerializer.ReadModelFromFile("../../../Pacman.uml", out var diagnostics);
            DiagnosticFormatter df = new DiagnosticFormatter();
            if (diagnostics.Any(d => d.Severity == DiagnosticSeverity.Error))
            {
                diagnostics = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).ToImmutableArray();
            }
            for (int i = 0; i < 10 && i < diagnostics.Length; i++)
            {
                Console.WriteLine(df.Format(diagnostics[i]));
            }
            Console.WriteLine(model);
            foreach (var cls in model.Objects.OfType<Class>())
            {
                Console.WriteLine(cls.Name);
                foreach (var prop in cls.OwnedAttribute)
                {
                    
                    Console.WriteLine($"  {prop.Name}: {prop.Type.Name}");
                }
                foreach (var op in cls.OwnedOperation)
                {
                    Console.WriteLine($"  {op.Name}()");
                }
            }
            foreach (var ir in model.Objects.OfType<InterfaceRealization>())
            {

                Console.WriteLine(ir.Client.FirstOrDefault() + " --|> " + ir.Supplier.FirstOrDefault());
            }
            foreach (var gen in model.Objects.OfType<Generalization>())
            {
                Console.WriteLine(gen.Specific + " -|> " + gen.General);
            }
            foreach (var dep in model.Objects.OfType<Dependency>())
            {
                Console.WriteLine(dep.Client.FirstOrDefault() + " --> " + dep.Supplier.FirstOrDefault());
            }
            foreach (var assoc in model.Objects.OfType<Association>())
            {
                Console.WriteLine(assoc.MemberEnd[0] + " - " + assoc.MemberEnd[1]);
            }

        }
    }
}
