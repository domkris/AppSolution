import React, {Component} from 'react';
import AuthService from '../Auth/AuthService';
import {Form, Button, Container, Row, Col, Card, FormGroup, FormControl, Alert} from 'react-bootstrap';

import logo from '../../assets/logo.png';
import loginImg from '../../assets/login-xxl.png';

import './LoginForm.css';

const Auth = new AuthService();
class LoginForm extends Component {

    constructor(props){

        super(props);
        this.state = {
            username : "",
            password: "",
            invalidLogin : false
        };
    }

    componentWillMount(){
        if(Auth.loggedIn() === true){

            this.props.history.replace('/home');
        }
    }
    
    handleChange = event => {
        this.setState({
            [event.target.id] : event.target.value
        });
        this.setState({
            invalidLogin: false
        });
    }

    handleSubmit = async event =>{
        event.preventDefault();
        const api_call = await Auth.login(this.state.username, this.state.password);
        if(api_call){
            this.props.history.replace('/home');
            this.setState({
                invalidLogin: false
            });
        }else{
            this.setState({
                invalidLogin: true
            });
        }
    }

    validateForm(){
        return this.state.username.length > 0 && this.state.password.length > 0;
    }

    render(){
        
        return (
            <div id="Main">
                <Container style = {{width : "100vw"}} id="LoginContainer">
                    <Row style = {{height : "25vh"}}></Row>
                    <Row>
                        <Col></Col>
                        <Col>
                            <Card id="LoginCard">
                                <Card.Header id="LoginCardHeader">
                                    <Card.Img variant="top" src={logo} id="LogoImage"/>
                                </Card.Header>
                                
                                <Card.Body>
                                    <form onSubmit={this.handleSubmit} id ="LoginForm">
                                        <FormGroup as={Row} controlId="username">
                                            <Form.Label>Username</Form.Label>
                                            <FormControl type="text" 
                                                         value ={this.state.username} 
                                                         placeholder="Enter username"
                                                         onChange={this.handleChange}>
                                            </FormControl>
                                        </FormGroup>
                                        <FormGroup as={Row} controlId="password">
                                            <Form.Label>Password</Form.Label>
                                            <FormControl type="password" 
                                                         value={this.state.password} 
                                                         placeholder="Enter password"
                                                         onChange={this.handleChange}>
                                            </FormControl>
                                        </FormGroup>
                                        <Form.Group as={Row}>
                                            <Form.Check type="checkbox" label="Remember me" />
                                        </Form.Group>
                                        <Row id="myRow">
                                            <Button id="myButton"variant="success" type="submit" disabled={!this.validateForm()}>
                                                <Row>
                                                    <Col xs={1}><img src={loginImg} alt="" id="LoginButtonImg"/></Col>
                                                    <Col id="LoginButtonText">Login</Col>
                                                </Row>  
                                            </Button>
                                        </Row>
                                    </form>
                                </Card.Body>
                            </Card>
                        </Col>
                        <Col></Col>
                    </Row>
                    <Row>
                        <Col></Col>
                        <Col>
                            <Alert id="wrongInputAlert"  hidden = {!this.state.invalidLogin}>
                                <div>
                                    Wrong username or/and password!
                                </div>
                            </Alert>
                        </Col>
                        <Col></Col>
                    </Row>
                </Container>
            </div>
        );
    }
}

export default LoginForm;