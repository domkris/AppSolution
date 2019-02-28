import React, { Component } from "react";
import Navigation from "../Navigation/Navigation";


export default class Layout extends Component {
    render() {
      //console.log(this.props);
    return (
      <div>
            <Navigation />
           {this.props.children}
      </div>
    );
  }
}