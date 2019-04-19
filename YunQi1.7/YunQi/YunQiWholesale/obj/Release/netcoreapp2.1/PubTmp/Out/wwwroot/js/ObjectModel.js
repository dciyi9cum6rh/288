function cart(productId,sizeId, colorId, quantity, product, price,size,color) {
    this.productId = productId;
    this.sizeId = sizeId;
    this.colorId = colorId;
    this.quantity = quantity;
    this.product = product;
    this.price = price;
    this.size = size;
    this.color = color;
}
function ContactData(MemberName, MemberMobile, Phone, ContactAddress, eMail, Freight) {
    this.MemberName = MemberName;
    this.MemberMobile = MemberMobile;
    this.Phone = Phone;
    this.ContactAddress = ContactAddress;
    this.eMail = eMail;
    this.Freight = Freight;
}
function Freight(FreightValue, OutFreightValue) {
    this.FreightValue = FreightValue;
    this.OutFreightValue = OutFreightValue;
    this.TrueOutFreightValue = 0;
}
