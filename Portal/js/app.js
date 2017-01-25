(function () {

    var apiPort = "32456";
    var portalPort = "52518";
    var portalHostname = "localhost";     var expectedPortalUrl = "http://" + portalHostname + ":" + portalPort;
     function init() {
        try {

            var pageUrl = document.location.href;

            validatePageUrl(pageUrl);

            var apiUrl = determineApiUrl(pageUrl);
            callApi(apiUrl);

        } catch (exception) {
            if (exception instanceof NotFoundException) {
                alert(exception.message);
            } else if (exception instanceof InternalServerErrorException) {
                alert(exception.message);
            } else if (exception instanceof RedirectException) {
                alert("Let's redirect to " + exception.redirectUrl);
            } else {
            //TODO moet ik deze wel afvangen? Want wat gebeurt er als ik bijv. syntaxfouten in de code maak?
                alert("some other exception...");
            }
        }
    }      function callApi(apiUrl) {
        //TODO...
    }      function validatePageUrl(pageUrl) {
        // The page url must start with the expected hostname but must not contain index.html.
        var valid = pageUrl.startsWith(expectedPortalUrl) && !pageUrl.startsWith(expectedPortalUrl + "/index.html");
        if (!valid) {
            throw new NotFoundException(pageUrl);
        }
    }      function determineApiUrl(pageUrl) {
        var apiUrl = pageUrl.replace(portalPort, apiPort);
        return apiUrl;
    }
     // Start the application.     init();

})();