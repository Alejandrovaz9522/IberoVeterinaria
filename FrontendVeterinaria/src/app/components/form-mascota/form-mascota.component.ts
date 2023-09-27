import { Component } from '@angular/core';
import { Mascota } from 'src/app/models/mascota';
import { MascotaService } from '../../services/mascota.service';
import { ToastrService } from 'ngx-toastr';
import { PropietarioService } from 'src/app/services/propietario.service';
import { Propietario } from '../../models/propietario';
import { TipoService } from '../../services/tipo.service';
import { RazaService } from '../../services/raza.service';
import { Tipo } from 'src/app/models/tipo';
import { Raza } from 'src/app/models/raza';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-form-mascota',
  templateUrl: './form-mascota.component.html',
  styleUrls: ['./form-mascota.component.scss']
})
export class FormMascotaComponent {

  idMascota : number = 0
  mascota: Mascota = {}
  propietarios: Propietario[] = []
  tipos: Tipo[] = []
  razas: Raza[] = []  

  constructor(private mascotaService: MascotaService,
              private propietarioService: PropietarioService,
              private tipoService: TipoService,
              private razaService: RazaService,
              private toastr: ToastrService,
              private aRoute: ActivatedRoute,
              private router: Router) {   
                this.idMascota = Number(this.aRoute.snapshot.paramMap.get('id'))
              }

  ngOnInit(): void {
    this.obtenerMascota(this.idMascota)
    this.obtenerPropietarios()
    this.obtenerTipos()
    this.obtenerRazas()
  }

  obtenerPropietarios() {
    this.propietarioService.getListPropietarios().subscribe(data => {
      this.propietarios = data           
    })
  }

  obtenerMascota(idMascota: number) {
    if(this.idMascota > 0){
      this.mascotaService.getMascota(idMascota).subscribe(data => {
        this.mascota = data[0]   
      })
    }
  }

  obtenerTipos(){
    this.tipoService.getTipos().subscribe(data => {
      this.tipos = data
    })
  }

  obtenerRazas(){
    this.razaService.getRazas().subscribe(data => {
      this.razas = data
    })
  }

  editarRegistrarMascota(){  
    if(this.idMascota > 0){
      this.mascotaService.editMascota(this.mascota, this.idMascota).subscribe(data => {
        this.toastr.success(data.message)
      })
    }
    else{
      this.mascotaService.saveMascota(this.mascota).subscribe(data => {
        this.toastr.success(data.message)
      },error => {
        this.toastr.error('Opps... Ocurrió un error!', 'Error')
        this.router.navigate(['/mascotas'])
      })
    }
  }

}
