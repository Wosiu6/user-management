using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using UserManagement.UserApi.Models;

namespace UserManagement.UI.Components.Pages.Users;

public partial class UserUpsertPanel : IDialogContentComponent
{
    [Parameter]
    public UserEntity Content { get; set; } = default!;

    bool isBusy;

    protected override async Task OnInitializedAsync()
    {
        isBusy = false;
    }

    public const string CalendarStyling = "background: padding-box linear-gradient(var(--neutral-fill-input-rest), var(--neutral-fill-input-rest)), border-box var(--neutral-stroke-input-rest) !important;\r\n    box-sizing: border-box !important;\r\n    position: relative !important;\r\n    color: inherit !important;\r\n    border: calc(var(--stroke-width)* 1px) solid transparent !important;\r\n    border-radius: calc(var(--control-corner-radius)* 1px) !important;\r\n    height: calc((var(--base-height-multiplier) + var(--density))* var(--design-unit)* 1px) !important;\r\n    font-family: inherit !important;\r\n    font-size: inherit !important;\r\n    line-height: inherit !important;\r\n    display: flex !important;";
}