
import React, { Component } from 'react';

var StringPair = ({name,title, state, onChange})=> {
    return (<div>
        <label htmlFor={name}>{title}</label>
        <input placeholder={title} name={name} value={state} onChange={e => onChange(e.target.value)} />
    </div>
    );
}
// see also: https://github.com/ImaginaryDevelopment/uber-lift/blob/master/client/table.tsx
// the ide complains about the typing here, but the runtime complains without it
var bindAllTheThings = function(this: object, prototype){
    Object.getOwnPropertyNames(prototype).filter(x => x != "constructor").map(x => {
        // console.log('checking:' + x);
        if (typeof (this[x]) === "function" && x !== 'render') {
            // console.log('binding:' + x);
            this[x] = this[x].bind(this);
        }
    });
};

export class Registration extends Component {
  static displayName = Registration.name;

  constructor(props) {
    super(props);
    bindAllTheThings.call(this, Registration.prototype);
    this.state = { lastName:'', firstName:'', npi:'', addr:'', tele:'', email:''};
  }
  saveData(){
    localStorage.setItem("registration", JSON.stringify(this.state));
  }
  render() {
    var createOnChange = name => value => {
        var next = {};
        next[name] = value;
        this.setState(next);
    };
    return (
      <div>
        <h1>Registration</h1>

        {
            [
                {name:'lastName', title:'Last Name'},
                {name:'firstName', title:'First Name'},
                {name:'npi', title:'NPI Number'},
                {name:'addr', title:'Business Address'},
                {name:'tele', title:'Telephone #'},
                {name:'email', title:'Email Address'}
            ].map(x => (<StringPair key={x.name} name={x.name} title={x.title} onChange={createOnChange(x.name)} />))
        }
        <div>Your Data:
        <p>{JSON.stringify(this.state)}</p>
        </div>

        <button className="btn btn-primary" onClick={this.saveData}>Save</button>
      </div>
    );
  }
}