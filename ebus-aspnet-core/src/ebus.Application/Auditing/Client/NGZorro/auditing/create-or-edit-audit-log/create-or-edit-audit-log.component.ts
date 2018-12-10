
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateAuditLogInput,AuditLogEditDto, AuditLogServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-audit-log',
  templateUrl: './create-or-edit-audit-log.component.html',
  styleUrls:[
	'create-or-edit-audit-log.component.less'
  ],
})

export class CreateOrEditAuditLogComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: AuditLogEditDto=new AuditLogEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _auditLogService: AuditLogServiceProxy
	) {
		super(injector);
    }

    ngOnInit() :void{
		this.init();
    }


    /**
    * 初始化方法
    */
    init(): void {
		this._auditLogService.getForEdit(this.id).subscribe(result => {
			this.entity = result.auditLog;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateAuditLogInput();
		input.auditLog = this.entity;

		this.saving = true;

		this._auditLogService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
