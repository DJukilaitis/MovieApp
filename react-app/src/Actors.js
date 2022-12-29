import React,{Component, useState} from 'react';
import {variables} from './Variables.js'
import { tsConstructorType} from '@babel/types'
import {useDate} from './useDate.js'    
        
export class Actors extends Component{
        
            constructor (props){
                super(props);
        
                this.state={
                    actors:[],
                    modalTitle:"",
                    ActorName:"",
                    ActorId:0,
                    selectedActor:null,
                    search:'',
                }
            }
        
            refreshList(){
                fetch(variables.API_URL+'actor')
                .then(response=>response.json())
                .then(data=>{
                    this.setState({actors:data});
                })
            }
        
        
        
            componentDidMount(){
                this.refreshList();
            }
        
            changeActorName =(e)=>{
                this.setState({changeActorName:e.target.value});
            }
        
            addClick(){
                this.setState({
                    modalTitle:"Add Actor",
                    actorId:0,
                    ActorName:""
                });
            }
        
        
            editClick(x){
                this.setState({
                    modalTitle:"Edit Actor",
                    actorId:x.actorId,
                    ActorName:x.name,
                    selectedActor:x,
                });
            }
        
            close(){
                this.setState({selectedActor:null});
            }
        
            deleteClick(id){ 
                fetch(variables.API_URL+`actor/${id}`,{
                    method:'DELETE',
                    headers:{
                        'Accept':'application/json',
                        'Content-Type':'application/json'
                    }
                    
                })
                    .then(res=>res.json())
                    .then((result)=>{
                        this.refreshList();
                        /*
                        },(error)=>{
                        alert('Failedddd');
                        this.refreshList();
                        */ 
        
                    });
                }
        
                SelectClick(actor){
                    this.setState({selectedActor:actor})
                }
        
        
            createClick(){ 
                
                let ActorInfo={
                    actorId:1,
                    name:this.refs.name.value
                }
                
                fetch(variables.API_URL+'actor',{
                    method:'POST',
                    headers:{
                        'Accept':'application/json',
                        'Content-Type':'application/json'
                    },
                    body:JSON.stringify(
                        //ActorName:this.state.ActorName
                        (ActorInfo)
                    )
                })
                    .then(res=>res.json())
                    .then((result)=>{
                        alert(result);
                        this.refreshList();
                        /*
                        },(error)=>{
                        alert('Failedddd');
                        this.refreshList();
                        */ 
        
                    });
                }
        
                SelectClick(actor){
                    this.setState({selectedActor:actor})
                }
        
            UpdateClick(){ 
            
                let ActorInfo={
                    actorId:this.state.selectedActor.actorId,
                    name:this.refs.name.value
                }
                fetch(variables.API_URL+'actor',{
                    method:'PUT',
                    headers:{
                        'Accept':'application/json',
                        'Content-Type':'application/json'
                    },
                    body:JSON.stringify(
                        //ActorName:this.state.ActorName
                        (ActorInfo)
                    )
                })
                    .then(res=>res.json())
                    .then((result)=>{
                        alert(result);
                        this.refreshList();
                        /*
                        },(error)=>{
                        alert('Failedddd');
                        this.refreshList();
                        */ 
        
                    });
                }
            
        
            render(){
                const{
                    actors,
                    modalTitle,
                    ActorName,
                    ActorId,
                    selectedActor,
                    search
                }=this.state;
                return(
                    <div>
                        <button type="button"
                        className="btn btn-primary m-2 float-end"
                        data-bs-toggle="modal"
                        data-bs-target="#exampleModal"
                        onClick={()=>this.addClick()}>
                            Add Actor
                        </button>

        
                        <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>
                                Name
                            </th>
                        </tr>
        </thead>
        <tbody>
            {actors.map(x=>
            <tr key={x.actorId}>
                <td>{x.name}</td>
                <td>
                <button type="button"
                        className="btn btn-primary m-2 float-end"
                        data-bs-toggle="modal"
                        data-bs-target="#exampleModal"
                        onClick={()=>this.editClick(x)}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                    <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                    </svg>
                    </button>
        
                    <button type="button" className="btn btn-light mr-1" onClick={()=>this.deleteClick(x.actorId)}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash3-fill" viewBox="0 0 16 16">
                    <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z"/>
                    </svg>
                    </button>
        
        
                </td>
            </tr>
            )}
        </tbody>
        
                        </table>
                        <div className="modal fade" id="exampleModal" tabIndex="1" aria-hidden="true">
                            <div className="modal-dialog modal-lg modal-dialog-centered">
                                <div className="modal-content">
                                    <div className="modal-header">
                                        <h5 className="modal-title">{modalTitle}</h5>
                                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={()=>this.close()}></button>
                                    </div>
        <div className="modal-body">
               
            <div className="input-group mb-3">
                <span className="input-group-text">Name</span>
                <input type="text" className="form-control" ref="name"
                defaultValue={selectedActor?.name} 
                onChange={this.changeActorName}/>
            </div>
        
                {!selectedActor&&
                <button type="button"
                className="btn btn-primary float-start"
                onClick={()=>this.createClick()}
                >
                    Create
                </button>
                }
        
                {selectedActor&&
                <button type="button"
                className="btn btn-primary float-start"
                onClick={()=>this.UpdateClick()}>
                    Update
                </button>
                }        
        
            </div>
                                </div>
                            </div>
                        </div>
                    </div>
                )
        
        
            }
        
        }