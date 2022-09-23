using Microsoft.AspNetCore.Components;
using MorphShared.Models;
using MorphShared.Services;

namespace MorphShared.Components
{
    public partial class MorphWord
    {
        [Inject]
        IApiService? Api { get; set; }

        [Parameter]
        public bool HideTooltips { get; set; } = false;

        [Parameter]
        public EventCallback<MorphShared.Models.ClipboardEventArgs> OnCopyRequest { get; set; }

        [Parameter]
        public EventCallback<ShareEventArgs> OnShare { get; set; }

        [Parameter]
        public string? Word { get; set; }

        private WordDecomposition? Decomposition { get; set; }
        private bool IsLoading { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Word == null)
            {
                throw new ArgumentException($"{nameof(MorphWord)} requires a word argument.");
            }

            if (Api == null)
            {
                throw new ApplicationException($"Service nameof({Api} wasn't injected into {this.GetType().Name}");
            }

            if (Decomposition?.Word?.L1 != Word)
            {
                this.IsLoading = true;
                StateHasChanged();

                this.Decomposition = await Api.GetWordDecomposition(Word);
                this.IsLoading = false;
                StateHasChanged();
            }
        }

        private async Task OnCopyClicked(string text)
            => await OnCopyRequest.InvokeAsync(new Models.ClipboardEventArgs(text));

        private async Task OnShareClicked()
            => await OnShare.InvokeAsync(new ShareEventArgs($"https://morphwasm.azurewebsites.net/word/{this.Word}"));
    }
}
