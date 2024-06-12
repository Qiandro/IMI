// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const baseUrl = "https://localhost:5001/";

//identifiers
const nameIdentifierClaimTypeKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

//axios config
let axiosConfig = {
    headers: { Authorization: `Bearer ${sessionStorage.getItem("token")}` }
};

//methods
function getDecodedToken() {
    const token = sessionStorage.getItem("token");
    if (token == null) {
        return "";
    }
    else {
        const decodedToken = jwt_decode(token);
        return decodedToken;
    }
}

function readUserIdFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[nameIdentifierClaimTypeKey];
}