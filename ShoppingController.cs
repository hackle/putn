using System;

namespace Putn
{
    public class ShoppingController
    {
        public void Checkout(BuyRequest request)
        {
            ShoppingService.Checkout(
                request.PromoCode, 
                DateTime.Now,
                () => {
                    var member = MemberRepository.FindByID(ContextualMemberID);
                    if (member == null)
                        throw new MemberNotFoundException(ContextualMemberID);

                    return member;
                },
                () => ItemRepository.FindByIDs(request.ItemIDs) ?? new Item[]{},
                total => {
                    LoggingService.Log(LogLevel.Info, $"Member {ContextualMemberID} charged {total}");
                    PaymentService.Charge(ContextualMemberID, total);
                });
        }

        private int ContextualMemberID = 20190620;
    }
}