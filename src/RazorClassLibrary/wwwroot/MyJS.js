export function setDisplayModeByElementId(elementId, mode)
{
    document.getElementById(elementId).style = "display: " + mode + " !important;";
};

export function scrollToBottom(elementName)
{
    var element = document.getElementById(elementName);
    if (element != null)
        element.scrollTop = element.scrollHeight - element.clientHeight;
};

export function readClipboardText() {
    return navigator.clipboard.readText;
}

export function writeClipboardText(text) {
    navigator.clipboard.writeText(text);
}

export function showAlert(text) {
    alert(text);
}