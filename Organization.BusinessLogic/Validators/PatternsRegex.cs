namespace Organization.BusinessLogic.Validators
{
    public static class PatternsRegex
    {
        public static readonly string Phone = @"^[\d]{10,20}";
        public static readonly string Name = @"^[A-ZА-ЯЁ][a-zа-яё\s\']*";
        public static readonly string DepartmentName = @"^[A-Z][^(,./\\!@%^&*)_=\-\+\)]*";
    }
}
