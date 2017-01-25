// 404 Not Found.
function NotFoundException(message) {
    this.message = message;
}
NotFoundException.prototype = new Error(); 
// 302 Found.
function RedirectException(message, redirectUrl) {
    this.message = message;
    this.redirectUrl = redirectUrl;
}
RedirectException.prototype = new Error(); 
// 500 Internal Server Error.
function InternalServerErrorException(message) {
    this.message = message;
}
InternalServerErrorException.prototype = new Error(); 