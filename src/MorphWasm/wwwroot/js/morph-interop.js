const morph = {
    copyText: function (text) {
        navigator.clipboard.writeText(text)
            .then(() => {
                return { isSuccessful: true };
            })
            .catch((error) => {
                return {
                    isSuccessful: false,
                    message: error
                };
            });
    }
}

window.morph = morph;
