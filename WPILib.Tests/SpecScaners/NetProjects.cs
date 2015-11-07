﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HAL_Simulator;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace WPILib.Tests.SpecScaners
{
    public static class GetNativeMethodExtension
    {

        public static string GetNativeMethod(this MethodDeclarationSyntax method)
        {
            try
            {
                return
                    method.AttributeLists[0].Attributes[0].ArgumentList.Arguments[1].ToString().Split('=')[1].Trim(' ',
                        '\"');
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    /// <summary>
    /// This class contains methods to get specific methods from DotNet projects
    /// </summary>
    public static class NetProjects
    {
        /// <summary>
        /// Gets a List of all the Functions with the Attribute <see cref="CalledSimFunction"/>
        /// </summary>
        /// <returns></returns>
        public static List<HALMethodClass> GetHALSimMethods()
        {
            List<HALMethodClass> halSimMethods = new List<HALMethodClass>();
            var dir = "..\\..\\HAL-Simulation\\HAL-Files";
            foreach (var file in Directory.GetFiles(dir, "*.cs"))
            {
                HALMethodClass cs = new HALMethodClass
                {
                    ClassName = "",
                    Methods = new List<MethodDeclarationSyntax>()
                };

                using (var stream = File.OpenRead(file))
                {
                    var tree = CSharpSyntaxTree.ParseText(SourceText.From(stream), path: file);
                    cs.ClassName = Path.GetFileName(file);
                    var methods =
                        tree.GetRoot()
                            .DescendantNodes()
                            .OfType<AttributeSyntax>()
                            .Where(a => a.Name.ToString() == nameof(CalledSimFunction))
                            .Select(a => a.Parent.Parent)
                            .Cast<MethodDeclarationSyntax>();
                    var methodDeclarationSyntaxs = methods as IList<MethodDeclarationSyntax> ?? methods.ToList();
                    if (methodDeclarationSyntaxs.Count != 0)
                    {
                        cs.Methods.AddRange(methodDeclarationSyntaxs);
                        halSimMethods.Add(cs);
                    }

                }


            }
            return halSimMethods;
        }

        public static List<HALMethodClass> GetHalRoboRioDllImports()
        {
            List<HALMethodClass> halRoboRioDllImports = new List<HALMethodClass>();
            var dir = "..\\..\\HAL-RoboRIO";
            foreach (var file in Directory.GetFiles(dir, "*.cs"))
            {
                //List<MethodDeclarationSyntax> methodList = new List<MethodDeclarationSyntax>();
                HALMethodClass cs = new HALMethodClass
                {
                    ClassName = "",
                    Methods = new List<MethodDeclarationSyntax>()
                };
                using (var stream = File.OpenRead(file))
                {
                    var tree = CSharpSyntaxTree.ParseText(SourceText.From(stream), path: file);
                    cs.ClassName = Path.GetFileName(file);
                    var methods =
                        tree.GetRoot()
                            .DescendantNodes()
                            .OfType<AttributeSyntax>()
                            .Where(a => a.Name.ToString() == "DllImport")
                            .Select(a => a.Parent.Parent)
                            .Cast<MethodDeclarationSyntax>();
                    cs.Methods.AddRange(methods);
                }
                halRoboRioDllImports.Add(cs);
            }

            return halRoboRioDllImports;
        }

        /// <summary>
        /// Gets a list of all RoboRIO functions
        /// </summary>
        /// <returns></returns>
        public static List<HALMethodClass> GetHalRoboRioMethods()
        {
            List<HALMethodClass> halRoboRioMethods = new List<HALMethodClass>();
            var dir = "..\\..\\HAL-RoboRIO";
            foreach (var file in Directory.GetFiles(dir, "*.cs"))
            {
                HALMethodClass cs = new HALMethodClass
                {
                    ClassName = "",
                    Methods = new List<MethodDeclarationSyntax>(),
                };
                using (var stream = File.OpenRead(file))
                {
                    var tree = CSharpSyntaxTree.ParseText(SourceText.From(stream), path: file);
                    cs.ClassName = Path.GetFileName(file);
                    var methods =
                        tree.GetRoot()
                            .DescendantNodes()
                            .OfType<MethodDeclarationSyntax>()
                            .Select(a => a).ToList();

                    cs.Methods.AddRange(methods);
                    halRoboRioMethods.Add(cs);
                }
                
            }

            return halRoboRioMethods;
        }

        public static List<HALDelegateClass> GetHalBaseDelegates()
        {
            List<HALDelegateClass> halBaseMethods = new List<HALDelegateClass>();
            var dir = "..\\..\\HAL-Base\\Generated";
            foreach (var file in Directory.GetFiles(dir, "*.cs"))
            {
                HALDelegateClass cs = new HALDelegateClass
                {
                    ClassName = "",
                    Methods = new List<DelegateDeclarationSyntax>()
                };
                using (var stream = File.OpenRead(file))
                {
                    var tree = CSharpSyntaxTree.ParseText(SourceText.From(stream), path: file);
                    cs.ClassName = Path.GetFileName(file);
                    var methods =
                        tree.GetRoot()
                            .DescendantNodes()
                            .OfType<DelegateDeclarationSyntax>()
                            .Select(a => a).ToList();
                    cs.Methods.AddRange(methods);
                }
                halBaseMethods.Add(cs);
            }

            return halBaseMethods;
        }
    }
}
