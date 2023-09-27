import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Propietario } from 'src/app/models/propietario';
import { PropietarioService } from 'src/app/services/propietario.service';

@Component({
  selector: 'app-propietario',
  templateUrl: './propietario.component.html',
  styleUrls: ['./propietario.component.scss']
})
export class PropietarioComponent {

  listPropietarios: Propietario[] = []
 
  constructor(private propietarioService: PropietarioService,
              private toastr: ToastrService) {   }

  ngOnInit(): void {
    this.obtenerPropietario()
  }

  obtenerPropietario() {
    this.propietarioService.getListPropietarios().subscribe(data => {
      this.listPropietarios = data            
    })
  }

  eliminarPropietario(propietarioId: number | undefined) {
    if(confirm('¿Esta seguro que desea eliminar el cuestionario?')){
      this.propietarioService.deletePropietario(propietarioId).subscribe(data => {        
        this.obtenerPropietario()
        console.log(data);
        this.toastr.success(data.message)
      })
    }
  }
}
