import decode from 'jwt-decode'

export default class AuthService{
    constructor(){
        this.domain = 'https://localhost:44302/api/login'
    }


    async login(username, password)
    {
        const postBody =  { 'username' : username, 'passwordHash' : password};
        const postObject = {
          method: 'POST',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(postBody)
        }


        const api_call = await fetch(this.domain, postObject);
        const data = await api_call.json();

        if(data.success === true){
            console.log("token is seet");
            this.setToken(data.token);
            return data;
        }
        else 
            return null;
        
        //console.log(data);

        // const promise = await fetch(this.domain, postObject);
        // if(this.checkResponseStatus(promise)){
        //     return promise.json();
        // }
        
        // return fetch(this.domain, postObject)
        // .then()
        // .then(this.checkResponseStatus)
        // .then(response => response.json())
        // .then(jsondata => {
        //     this.setToken(jsondata.token)

        // });
    }
    setToken(token)
    {
        localStorage.setItem('token', token);
    }

    getToken()
    {
        return localStorage.getItem('token');
    }
    logout()
    {
        localStorage.removeItem('token');
    }
    loggedIn()
    {
        const token = this.getToken();
        return !!token && !this.isTokenExpired(token);
    }
    checkResponseStatus(response)
    {
       
        // raises an error in case response status is not a success
        if (response.status >= 200 && response.status < 300) { // Success status lies between 200 to 300
            console.log(response);
            return true
        } else {
           
            console.log(response);
            return false;
        }
    }
    isTokenExpired(token){
        try
        {
            const decoded = decode(token);
            if(decoded.exp < Date.now() / 1000)
            {
                return true;
            }
            else
            {  
                return false;
            }
        }
        catch(error)
        {
            return false;
        }
    }
    getProfile(){
        return decode(this.getToken());
    }


    
}