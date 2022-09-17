const morph = {
    wait: function (text) {
        setTimeout(morph.copyText(text), 2000);
    },

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
