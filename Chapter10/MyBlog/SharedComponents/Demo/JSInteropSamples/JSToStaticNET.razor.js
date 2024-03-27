
window.callnetfromjs = () => {
    DotNet.invokeMethodAsync('SharedComponents', 'NameOfTheMethod')
        .then(data => {
            alert(data);
        });
};
