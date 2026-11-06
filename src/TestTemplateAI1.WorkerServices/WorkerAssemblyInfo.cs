using System.Reflection;


namespace TestTemplateAI1.WorkerServices
{
    public static class WorkerAssemblyInfo
    {
        public static Assembly Value { get; } = typeof(WorkerAssemblyInfo).Assembly;
        public static string ServiceName { get; } = "TestTemplateAI1";
    }
}
