using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using UserManagment.UserApi.Models;

namespace UserManagment.UI.Components.Pages.Users;

public partial class UserViewPanel : IDialogContentComponent
{
    [Parameter]
    public UserEntity Content { get; set; } = default!;

    bool isBusy;

    protected override async Task OnInitializedAsync()
    {
        isBusy = false;
    }
}