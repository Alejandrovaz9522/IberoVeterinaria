import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Mascota } from 'src/app/models/mascota';
import { MascotaService } from 'src/app/services/mascota.service';
import { RazaService } from 'src/app/services/raza.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.scss']
})
export class InicioComponent {

  listMascotas: Mascota[] = []
 
  constructor(private mascotaService: MascotaService,
              private toastr: ToastrService) { 
  }

  ngOnInit(): void {
    this.obtenerMascotas()
  }

  obtenerMascotas() {
    this.mascotaService.getListMascotas().subscribe(data => {
      this.listMascotas = data            
    })
  }

  eliminarMascota(mascotaId: number | undefined) {
    if(confirm('¿Esta seguro que desea eliminar el cuestionario?')){
      this.mascotaService.deleteMascota(mascotaId).subscribe(data => {        
        this.obtenerMascotas()
        console.log(data);
        this.toastr.success(data.message)
      })
    }
  }
}
