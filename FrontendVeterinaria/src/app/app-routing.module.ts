import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PropietarioComponent } from './components/propietario/propietario.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { FormMascotaComponent } from './components/form-mascota/form-mascota.component';
import { FormPropComponent } from './components/form-prop/form-prop.component';

const routes: Routes = [
  { path: '', redirectTo: '/mascotas',pathMatch:'full'},
  { path: 'mascotas', component: InicioComponent},
  { path: 'propietarios', component: PropietarioComponent},
  { path: 'form-mascota', component: FormMascotaComponent},
  { path: 'form-mascota/:id', component: FormMascotaComponent},
  { path: 'form-prop', component: FormPropComponent},
  { path: 'form-prop/:id', component: FormPropComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
