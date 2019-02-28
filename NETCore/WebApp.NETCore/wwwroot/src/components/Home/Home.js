import React, { Component } from 'react';
import AuthService from '../Auth/AuthService';
import './Home.css';


const Auth = new AuthService()
export default class Home extends Component {

    constructor(props) {
        super(props);
        this.state = {
            user: null
        }
        this.handleLogout = this.handleLogout.bind(this);
        
    }
    componentWillMount(){
        if (!Auth.loggedIn()) {
            console.log("Not logged in");
            this.props.history.push('/')
        }
        else {

            try {
                const profile = Auth.getProfile()
                this.setState({
                    user: profile.unique_name
                });
                console.log(this.state.user);

            }
            catch (err) {
                Auth.logout()
                console.log(err)
                this.props.history.replace('/')
            }
        }
    }
    render() {

        return (
            <div>
                <h2>Welcome {this.state.user}</h2>
                <p>
                    <button type="button" className="form-submit" onClick={this.handleLogout}>Logout</button>
                </p>
            </div>
        );
    }
    handleLogout() {
        Auth.logout();
        this.props.history.push('/');
    }
}