import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ImageModel } from 'src/app/models/imageModel';
import { SubscriptionCategoryModel } from 'src/app/models/subscriptionCategoryModel';
import { SubscriptionDetailModel } from 'src/app/models/subscriptionDetailModel';
import { SubscriptionModel } from 'src/app/models/subscriptionModel';
import {
  CustomSpinnerName,
  CustomSpinnerService,
} from 'src/app/services/common/custom-spinner.service';
import {
  CustomToastrService,
  ToastrMessageType,
  ToastrPosition,
} from 'src/app/services/common/custom-toastr.service';
import { ImageService } from 'src/app/services/common/image.service';
import { MailService } from 'src/app/services/common/mail.service';
import { SubscriptionService } from 'src/app/services/models/subscription.service';
import { SubscriptionCategoryService } from 'src/app/services/models/subscriptionCategory.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
})
export class MainComponent implements OnInit {
  images: ImageModel[];

  subscriptionModel: SubscriptionModel[];
  subscriptionCategory: SubscriptionCategoryModel[];
  subscriptionFitness: SubscriptionDetailModel[];
  subscriptionSwimming: SubscriptionDetailModel[];
  subscriptionPlates: SubscriptionDetailModel[];
  subscriptionBoks: SubscriptionDetailModel[];
  subscriptionFolkDance: SubscriptionDetailModel[];

  methmetBaltaci = MehmetInfo;
  gokhanSarikurt = GokhanInfo;
  serdarSarikurt = SerdarInfo;
  certificas = Certificas;

  instagram: string = 'https://www.instagram.com/omegagym34/';
  youtube: string = 'https://youtube.com/@OMEGAGYM34';
  mail: string = '34omegagym@gmail.com';
  tel: string = '0505 875 78 53';

  constructor(
    private subsctiptionService: SubscriptionService,
    private subcscriptionCategoryService: SubscriptionCategoryService,
    private mailService: MailService,
    private imageService: ImageService,
    private toastrService: CustomToastrService,
    private customSrpinner: CustomSpinnerService
  ) {}

  ngOnInit(): void {
    this.getAllImage();
    this.getAllSubscription();
    this.getAllSubscriptionCategory();

    this.getSubscriptionFitness();
    this.getSubscriptionSwimming();
    this.getSubscriptionBoks();
    this.getSubscriptionPlates();
    this.getSubscriptionFolkDance();
  }

  //Image Model Galery
  imageModelClick(
    model: HTMLDivElement,
    myImage: HTMLImageElement,
    modelImage: HTMLImageElement,
    closeBtn: HTMLSpanElement
  ) {
    model.style.display = 'block';
    modelImage.src = myImage.src;

    if ((model.style.display = 'block')) {
      closeBtn.onclick = () => {
        model.style.display = 'none';
      };

      model.onclick = () => {
        model.style.display = 'none';
      };
    }
  }

  //TODO:Subscrption GetAll
  getAllSubscription() {
    this.customSrpinner.showSpinner(CustomSpinnerName.spinner_one);
    this.subsctiptionService.getAll().subscribe(
      (response) => {
        this.subscriptionModel = response;
        this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
      },
      (httpErrorResponse: HttpErrorResponse) => {
        this.toastrService.alertMessage({
          message: `${httpErrorResponse.error} - ${httpErrorResponse.status}`,
          title: httpErrorResponse.error,
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopFullWidth,
        });
        console.log(httpErrorResponse);
      }
    );
    this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
  }

  //TODO:SubscriptionCategory Get All
  getAllSubscriptionCategory() {
    this.customSrpinner.showSpinner(CustomSpinnerName.spinner_one);
    this.subcscriptionCategoryService.getAll().subscribe(
      (response) => {
        this.subscriptionCategory = response;
        this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
      },
      (errorResponse: HttpErrorResponse) => {
        console.log(errorResponse);
        this.toastrService.alertMessage({
          message: `${errorResponse.error} - ${errorResponse.status}`,
          title: errorResponse.error,
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopRight,
        });
      }
    );
    this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
  }

  //TODO: Subscription Detail - Fitness
  getSubscriptionFitness() {
    this.customSrpinner.showSpinner(CustomSpinnerName.spinner_one);
    this.subsctiptionService.getByDetails(CategoryNames.fitness).subscribe(
      (response) => {
        this.subscriptionFitness = response;
        this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
      },
      (errorResponse: HttpErrorResponse) => {
        console.log(errorResponse);
        this.toastrService.alertMessage({
          message: `${errorResponse.error} - ${errorResponse.status}`,
          title: errorResponse.error,
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopRight,
        });
      }
    );
    this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
  }

  //TODO: Subscription Detail - Yüzme
  getSubscriptionSwimming() {
    this.customSrpinner.showSpinner(CustomSpinnerName.spinner_one);
    this.subsctiptionService.getByDetails(CategoryNames.yüzme).subscribe(
      (response) => {
        this.subscriptionSwimming = response;
        this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
      },
      (errorResponse: HttpErrorResponse) => {
        this.toastrService.alertMessage({
          message: `${errorResponse.error} - ${errorResponse.status}`,
          title: errorResponse.error,
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopRight,
        });
      }
    );
    this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
  }

  //TODO: Subscription Detail - Boks
  getSubscriptionBoks() {
    this.customSrpinner.showSpinner(CustomSpinnerName.spinner_one);
    this.subsctiptionService.getByDetails(CategoryNames.boks).subscribe(
      (response) => {
        this.subscriptionBoks = response;
        this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
      },
      (errorResponse: HttpErrorResponse) => {
        this.toastrService.alertMessage({
          message: `${errorResponse.error} - ${errorResponse.status}`,
          title: errorResponse.error,
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopRight,
        });
      }
    );
    this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
  }

  //TODO: Subscription Detail - Boks
  getSubscriptionPlates() {
    this.customSrpinner.showSpinner(CustomSpinnerName.spinner_one);
    this.subsctiptionService.getByDetails(CategoryNames.plates).subscribe(
      (response) => {
        this.subscriptionPlates = response;
        this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
      },
      (errorResponse: HttpErrorResponse) => {
        this.toastrService.alertMessage({
          message: `${errorResponse.error} - ${errorResponse.status}`,
          title: errorResponse.error,
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopRight,
        });
      }
    );
    this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
  }

  //TODO: Subscription Detail - Boks
  getSubscriptionFolkDance() {
    this.customSrpinner.showSpinner(CustomSpinnerName.spinner_one);
    this.subsctiptionService
      .getByDetails(CategoryNames.halk_oyunları)
      .subscribe(
        (response) => {
          this.subscriptionFolkDance = response;
          this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
        },
        (errorResponse: HttpErrorResponse) => {
          this.toastrService.alertMessage({
            message: `${errorResponse.error} - ${errorResponse.status}`,
            title: errorResponse.error,
            messageType: ToastrMessageType.Error,
            position: ToastrPosition.TopRight,
          });
        }
      );
      this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
  }

  //TODO: Image GetAll
  getAllImage() {
    this.imageService.getAllImage().subscribe((response) => {
      this.images = response;
    });
  }

  //TODO: Send Mail
  sendMail(
    firstName: string,
    lastName: string,
    email: string,
    body: string,
    event: Event
  ) {
    event.preventDefault();
    let isSuccess: boolean;
    this.mailService
      .singleSendMail({
        tos: ['muraterennar@gmail.com'],
        body: body,
        subject: `${email} ------- ${firstName} ${lastName}`,
        isBodyHtml: true,
      })
      .subscribe(
        (resposne) => {
          console.log(resposne);
          this.toastrService.alertMessage({
            message: 'Mesaj Başarıyla Gönderildi',
            title: '√ Gönderildi',
            messageType: ToastrMessageType.Success,
            position: ToastrPosition.TopRight,
          });
        },
        (httpErrorResponse: HttpErrorResponse) => {
          isSuccess = false;
          this.toastrService.alertMessage({
            message: `${httpErrorResponse.error} - ${httpErrorResponse.status}`,
            title: httpErrorResponse.error,
            messageType: ToastrMessageType.Error,
            position: ToastrPosition.TopRight,
          });
        }
      );

    if (isSuccess == true) {
      this.toastrService.alertMessage({
        message: 'Mesaj Başarıyla Gönderildi',
        title: '√ Gönderildi',
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight,
      });
    }
    this.customSrpinner.hideSpinner(CustomSpinnerName.spinner_one);
  }
}

export enum CategoryNames {
  fitness = 'fitness',
  boks = 'boks',
  plates = 'pilates',
  yüzme = 'yüzme',
  halk_oyunları = 'halk oyunları',
}

export enum MehmetInfo {
  id = 1,
  username = 'Mehmet Baltacı',
  img = 'assets/img/mehmet-baltaci.jpg',
  position = 'Kurucu Ortak / Antrenör',
}
export enum GokhanInfo {
  id = 2,
  username = 'Gökhan Sarıkurt',
  img = 'assets/img/gokhan-sarikurt.jpg',
  position = 'Kurucu Ortak / Antrenör',
}
export enum SerdarInfo {
  id = 3,
  username = 'Serdar Sarıkurt',
  img = 'assets/img/serdar-sarikurt.jpg',
  position = 'Kurucu Ortak / Antrenör',
}

export enum Certificas {
  LsnDipcertificaName = 'Lisans Diploması',
  LsnDipcertificaImg = 'assets/img/lisans.jpg',

  OnrBelCertificaName = 'Onur Belgesi',
  OnrBelcertificaImg = 'assets/img/onur.jpg',

  YrdAntCertificaName = 'Yardımcı Antrenör Belgesi / Vücut Geliştirme',
  YrdAntcertificaImg = 'assets/img/yardimci-antrenor.png',

  YrdAnt2CertificaName = 'Yardımcı Antrenör Belgesi / Yüzme',
  YrdAnt2CertificaImg = 'assets/img/yardimci-antrenor-2.png',
}
