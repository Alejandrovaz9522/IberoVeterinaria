import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Propietario } from 'src/app/models/propietario';
import { PropietarioService } from 'src/app/services/propietario.service';

@Component({
  selector: 'app-form-prop',
  templateUrl: './form-prop.component.html',
  styleUrls: ['./form-prop.component.scss']
})
export class FormPropComponent {

  idProp: number = 0
  propietario: Propietario = {}


  constructor(private propietarioService: PropietarioService,
              private toastr: ToastrService,
              private aRoute: ActivatedRoute,
              private router: Router) {  
                 this.idProp = Number(this.aRoute.snapshot.paramMap.get('id'))
               }
  
  ngOnInit(): void {
    this.obtenerPropietario(this.idProp)
  }

  registrarEditarPropietario(){ 
    if(this.idProp > 0){
      console.log(this.idProp)
      this.propietarioService.editPropietario(this.idProp, this.propietario).subscribe(data => {
        this.toastr.success(data.message)
      })
    }
    else{
      this.propietarioService.savePropietario(this.propietario).subscribe(data => {
        this.toastr.success(data.message)
      })
    }
  }

  obtenerPropietario(idProp: number){ 
    this.propietarioService.getPropietario(idProp).subscribe(data => {
      if(this.idProp > 0){
        this.propietario = data[0]
      }
    })
  }

}
