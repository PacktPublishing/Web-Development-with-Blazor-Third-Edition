window.callreferencenetfromjs = (dotNetHelper) => {
    return dotNetHelper.invokeMethodAsync('GetHelloMessage');
};