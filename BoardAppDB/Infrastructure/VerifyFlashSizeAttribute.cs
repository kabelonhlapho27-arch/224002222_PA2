// Group leader name : Kabelo Nhlapho
// Group Student nrs : 224042163; 220048471; 219005935; 224136508; 224069913; 223068452; 224037409
// Assignment nr     : SOD226C Practical Assessment 1 · 2026
// Purpose           : The purpose of this class is to provide custom model validation
//                     to ensure flash memory sizes conform to allowed power-of-two values.

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BoardAppDB.Infrastructure
{
    public class VerifyFlashSizeAttribute : Attribute, IModelValidator
    {
        public bool IsRequired
        {
            //
            //Name             : property bool IsRequired
            //Purpose          : Read-only property indicating whether validation is required
            //Re-use           : none
            //Input Parameter  : none
            //Output Type      : bool
            //                   true indicating validation must run
            //
            get
            {
                return true;
            } // end get
        } // end property

        public string ErrorMessage
        {
            //
            //Name             : property string ErrorMessage
            //Purpose          : Automatic public property to give access to corresponding compiler generated field
            //Re-use           : none
            //Input Parameter  : string value
            //                   new value for corresponding compiler generated field
            //Output Type      : string
            //                   value stored in the corresponding compiler generated field
            //
            get; set;
        } = "Valid flash sizes in KB are: 16, 32, 64, 128, 256, 512, 1024, 2048, 4096"; // end property

        private readonly List<int> validFlashSizes = new List<int>()
        {
            16, 32, 64, 128, 256, 512, 1024, 2048, 4096
        };

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            //
            //Name             : IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
            //Purpose          : Validates whether the supplied flash memory value matches allowed sizes
            //Re-use           : None
            //Method Parameters: ModelValidationContext context
            //                   context object containing the model property value being validated
            //Output Type      : IEnumerable<ModelValidationResult>
            //                   collection containing validation error if invalid; otherwise, empty collection
            //
            int? value = context.Model as int?;

            if (value == null || !validFlashSizes.Contains(value.Value))
            {
                return new List<ModelValidationResult>
                {
                    new ModelValidationResult("", ErrorMessage)
                };
            } // end if

            return Enumerable.Empty<ModelValidationResult>();
        } // end method
    } // end class VerifyFlashSizeAttribute
} // end BoardApp.Infrastructure
