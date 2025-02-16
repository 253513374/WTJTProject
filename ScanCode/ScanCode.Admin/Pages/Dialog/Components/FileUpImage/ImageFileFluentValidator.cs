﻿using FluentValidation;
using ScanCode.Web.Admin.Pages.Dialog.Components.FileUpImage;

namespace ScanCode.Web.Admin.Pages.FluentValidator
{
    public class ImageFileFluentValidator : AbstractValidator<FileModel>
    {
        public ImageFileFluentValidator()
        {
            // RuleFor(x => x.PrizeName).NotEmpty().WithMessage("奖品名称不能为空");
            RuleFor(x => x.File)
                .NotEmpty().When(w => string.IsNullOrEmpty(w.ImageBase64)).WithMessage("图片文件不能为空");
            RuleFor(x => x.ImageBase64)
                .NotEmpty().When(w => w.File == null).WithMessage("图片文件不能为空");

            When(x => x.File != null,
                () =>
                {
                    RuleFor(x => x.File.ContentType).Must(x => x == "image/jpeg" || x == "image/png").WithMessage("请上传格式为jpg与png格式图片");
                    RuleFor(x => x.File.Size).LessThanOrEqualTo(500000).WithMessage("上传的图片文件大小不能超过500kb");
                });
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<FileModel>.CreateWithOptions((FileModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}